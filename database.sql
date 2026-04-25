use defaultdb;

create table user (
    user_id int primary key auto_increment,
    name varchar(255) not null,
    phone_no varchar(15),
    email varchar(255) unique not null,
    role enum('Admin', 'Judge', 'Participant', 'Event Organizer', 'Sponsor')
);

create table judge (
    judge_id int primary key auto_increment,
    user_id int unique,
    foreign key (user_id) references user(user_id) on delete cascade
);

create table participant (
    part_id int primary key auto_increment,
    user_id int unique,
    foreign key (user_id) references user(user_id) on delete cascade
);

create table event_organizer (
    event_org_id int primary key auto_increment,
    user_id int unique,
    foreign key (user_id) references user(user_id) on delete cascade
);

create table sponsor (
    sponsor_id int primary key auto_increment,
    company_name varchar(255) not null,
    user_id int,
    foreign key (user_id) references user(user_id) on delete set null
);

alter table sponsor
add column category enum ('Title Sponsor', 'Gold Sponsor', 'Silver Sponsor', 'Media Partner');

create table teams (
    team_id int primary key auto_increment,
    name varchar(255) not null
);

create table events (
    event_id int primary key auto_increment,
    name varchar(255) not null,
    category enum ('Tech', 'Business', 'Gaming', 'General'),
    description varchar(5000),
    max_participants int,
    registration_fee decimal(10,2),
    event_org_id int,
    winner_prize int,
    runnerUp_prize int,
    foreign key (event_org_id) references event_organizer(event_org_id) on delete set null
);

create table venues (
    venue_id int primary key auto_increment,
    name varchar(255) not null
);

create table rounds (
    round_id int primary key auto_increment,
    name enum ('Prelim', 'Semi-Final', 'Final') not null
);

create table event_schedules (
    eve_s_id int primary key auto_increment,
    event_id int,
    venue_id int,
    date_time datetime not null,
    round_id int,
    foreign key (event_id) references events(event_id) on delete cascade,
    foreign key (round_id) references rounds(round_id) on delete set null,
    foreign key (venue_id) references venues(venue_id) on delete set null
);

create table sponsorship (
    ss_id int primary key auto_increment,
    sponsor_id int,
    event_id int,
    event_org_id int,
    amount_paid decimal(10,2),
    foreign key (sponsor_id) references sponsor(sponsor_id) on delete cascade,
    foreign key (event_id) references events(event_id) on delete cascade,
    foreign key (event_org_id) references event_organizer(event_org_id) on delete cascade
);

create table accommodations (
    accom_id int primary key auto_increment,
    event_org_id int,
    part_id int,
    budget enum ('None', '1000', '1500', '2000'),
    status enum ('pending', 'approved'),
    foreign key (event_org_id) references event_organizer(event_org_id) on delete cascade,
    foreign key (part_id) references participant(part_id) on delete cascade
);

-- relationship tables
create table team_participants (
    team_id int,
    part_id int,
    constraint pk_team_participants primary key (team_id, part_id),
    foreign key (team_id) references teams(team_id) on delete cascade,
    foreign key (part_id) references participant(part_id) on delete cascade
);

create table event_team (
    event_id int,
    team_id int,
    payment_status enum('paid', 'unpaid') default 'unpaid',
    payment_detail_id int,
    primary key (event_id, team_id),
    foreign key (payment_detail_id) references payment_detail(detail_id) on delete cascade
);
 alter table event_team
 drop column payment_status;

create table payment_detail (
    detail_id int auto_increment primary key,
    payer_id int,
    amount_payed decimal(10,2)
);
 alter table payment_detail
 add column payment_method enum ('Cash', 'credit Card');
  alter table payment_detail
 add column payment_status enum ('unpaid', 'paid');

create table event_judges (
    eve_s_id int,
    judge_id int,
    constraint pk_event_judges primary key (eve_s_id, judge_id),
    foreign key (eve_s_id) references event_schedules(eve_s_id) on delete cascade,
    foreign key (judge_id) references judge(judge_id) on delete cascade
);

create table evaluations (
    evaluation_id int primary key auto_increment,
    eve_s_id int,
    team_id int,
    score decimal(5,2),
    foreign key (eve_s_id) references event_schedules(eve_s_id) on delete cascade,
    foreign key (team_id) references teams(team_id) on delete cascade
);

alter table evaluations
add constraint unique_eve_team unique (eve_s_id, team_id);

create table team_round_tracking (
    track_id int primary key auto_increment,
    team_id int,
    eve_s_id int,
    status enum('qualified', 'eliminated'),
    foreign key (team_id) references teams(team_id),
    foreign key (eve_s_id) references event_schedules(eve_s_id)
);

-- a trigger that automatically fills the event_schedule based on the events
delimiter //
create trigger insert_event_schedules
after insert on events
for each row
begin
    insert into event_schedules (event_id, round_id)
    values 
        (new.event_id, 1),
        (new.event_id, 2),
        (new.event_id, 3);
end //
delimiter ;

-- trigger to fill the evaluation table when a team registers
delimiter //
create trigger insert_evaluation_on_event_team_insert
after insert on event_team
for each row
begin
    declare v_eve_s_id int;

    -- get the event_schedule id for round 1 
    select es.eve_s_id into v_eve_s_id
    from event_schedules es
    where es.event_id = new.event_id and es.round_id = 1;

    -- insert evaluation record for round 1 with null score
    insert into evaluations (eve_s_id, team_id, score)
    values (v_eve_s_id, new.team_id, null);
end //
delimiter ;

-- a trigger that automatically fills the tracking table based on the evaluation
delimiter //
create trigger fill_teamTracking_table
after update on evaluations
for each row
begin
	declare round_score decimal(5,2);
	select score into round_score
    from evaluations where eve_s_id = new.eve_s_id;

    insert into team_round_tracking (team_id, eve_s_id, status)
    values (new.team_id, new.eve_s_id,
	-- keeping 30 points as the threshold for qualifying 
    if(round_score >= 30, 'qualified', 'eliminated'));
end //
delimiter ;


-- creating trigger to set the event_schedule table
delimiter //
create trigger fill_event_schedule_table
after insert on events
for each row
begin
    insert into event_schedules (event_id, round_id)
    values (new.event_id, '1');
	insert into event_schedules (event_id, round_id)
    values (new.event_id, '2');
	insert into event_schedules (event_id, round_id)
    values (new.event_id, '3');
end //
delimiter ;

-- a trigger to fill the evaluation table
delimiter //
create trigger fill_evaluation_after_registration
after insert on event_team
for each row
begin
    declare team_id int;
	declare eve_s_id int;

    set team_id = new.team_id;
    set eve_s_id = (select eve_s_id from event_schedules
    where event_id = new.event_id and round_id = '1');

    -- insert a new evaluation record for the team
    insert into evaluations (eve_s_id, team_id, score)
    values (eve_s_id, team_id, null);
end //
delimiter ;

-- drop trigger fill_teamTracking_table; 

-- Creating views and procedures for the reports page

-- Event participation statistics
create view teams_per_event as
select e.name,  e.max_participants as total_team_capacity, count(et.team_id) as total_teams_registered
from event_team et
Natural join events e 
group by e.name, e.max_participants;

-- Venue utilization reports
-- Venue scheduling conflicts using JOIN on Event_Schedule
create view venue_utilization as
select e.name as event_name, r.name as round_name, e.start_time, e.end_time, v.name as venue_name
from event_schedules es
join events e on e.event_id = es.event_id
join venues v on v.venue_id = e.venue_id
join rounds r on r.round_id = es.round_id
order by e.category;

create view venue_count as
select v.name, count(e.venue_id) as venue_count
from venues v 
join events e on v.venue_id = e.venue_id
group by v.venue_id;

-- Revenue & sponsorship reports
-- Show sponsorship details with sponsor payments using LEFT JOIN
create view sponsorship_details as
select s.company_name as sponsor, e.name as event,
s.category as sponsorCategory, ss.amount_paid 
from sponsorship ss
left join sponsor s on ss.sponsor_id = s.sponsor_id
join events e on e.event_id = ss.event_id;

-- Accommodation occupancy reports
-- Generate a report of participants and their assigned accommodations using INNER JOIN
create view assigned_accomodations as
select u.name as participant, a.assignment_id, a.room_id, 
a.check_in_date, a.check_out_date
from accommodation_assignment a natural join 
accommodation_request ar 
natural join participant p
natural join user u;

-- drop view assigned_accomodations;

--  Participant demographics per specific event
delimiter //
create procedure get_participant_demographics(in event_name varchar(100))
begin
    select p.part_id as ID, u.name, u.phone_no, u.email, t.name as team_name 
	from participant p 
    join user u on u.user_id = p.user_id
    join team_participants tp on p.part_id = tp.part_id
    join teams t on tp.team_id = t.team_id
    join event_team et on t.team_id = et.team_id
    join events e on et.event_id = e.event_id
    where e.name = event_name;
end //
delimiter ;

-- making the "paid" trigger
-- by default we will store unpaid untill a full check is made
-- whether the fee is enough for the event!
delimiter //
create trigger check_payment_after_insert
after insert on event_team
for each row
begin
    declare fee decimal(10,2); 
    declare error_message varchar(100);
    declare amountPayed_var decimal(10,2);
    
    select pd.amount_payed into amountPayed_var 
    from payment_detail pd
    where detail_id = new.payment_detail_id;
	
	-- Get the registration fee for the event from the event_team and payment_detail
    select e.registration_fee into fee
    from events e where e.event_id = new.event_id;
	
   -- Check if fee is NULL
    if fee is NULL then
        set error_message = 'Error: Registration fee not found for the event.';
        signal sqlstate '45000'
        set message_text = error_message;
    else
        -- Set the error message after we get the fee
        set error_message = concat('Insufficient amount. You need ', fee - amountPayed_var, ' more.');

        -- If the payment is enough, update the payment status
        if amountPayed_var >= fee then
            update payment_detail
            set payment_status = 'paid'
            where detail_id = new.payment_detail_id;
        -- else 
            -- Trigger an error if the payment is not enough
           -- signal sqlstate '45000'
            -- set message_text = error_message;
        end if;
    end if;
end//
delimiter ;

delimiter //
create trigger limit_judges_per_event
before insert on event_judges
for each row
begin
    declare judge_count int;

    select count(*) into judge_count 
    from event_judges
    where eve_s_id = NEW.eve_s_id;

    if judge_count >= 3 then
        signal sqlstate '45000'
        set message_text = 'Sorry ! Maximum 3 judges allowed for this event round!
        hence your application is not considered...';
    end if;
end //
delimiter ;



 -- drop trigger check_payment_after_insert;
-- an event that sends notification to the
-- team about their remaining payment

-- set global event_scheduler = on;

-- delimiter //
-- create event send_payment_reminders
-- on schedule every 1 day -- runs daily
-- do
-- begin
--     insert into reminders (team_id, event_id, message)
--     select et.team_id, et.event_id,
--            concat('Reminder: Please complete the remaining payment. You are short by ₹', e.registration_fee - et.amount_payed)
--     from event_team et
--     join events e on et.event_id = e.event_id
--     where et.payment_status = 'Unpaid'
-- 	and et.amount_payed < e.registration_fee;
-- end //
-- -- delimiter;

-- adding venue id in the events table

ALTER TABLE events
ADD COLUMN venue_id INT,
DROP COLUMN venue,
ADD CONSTRAINT FOREIGN KEY (venue_id)
    REFERENCES venues(venue_id)
    ON DELETE SET NULL;

UPDATE events
SET venue_id = 3 
WHERE event_id = 3;


