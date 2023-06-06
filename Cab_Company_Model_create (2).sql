-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2023-06-01 14:24:55.001

-- tables
-- Table: cab
CREATE TABLE cab (
    id uniqueidentifier  NOT NULL,
    license_plate varchar(32)  NOT NULL,
    manufacture_year int  NOT NULL,
    active bit  NOT NULL DEFAULT 1,
    car_model varchar(25)  NOT NULL,
    CONSTRAINT cab_ak_1 UNIQUE (license_plate),
    CONSTRAINT cab_pk PRIMARY KEY  (id)
);

-- Table: cab_ride
CREATE TABLE cab_ride (
    id uniqueidentifier  NOT NULL,
    shift_id uniqueidentifier  NOT NULL,
    ride_start_time datetime  NOT NULL,
    ride_end_time datetime  NOT NULL,
    address_starting_point varchar(25)  NOT NULL,
    address_destination varchar(25)  NOT NULL,
    canceled bit  NOT NULL DEFAULT 0,
    payment_type_id uniqueidentifier  NOT NULL,
    price decimal(10,2)  NULL,
    CONSTRAINT cab_ride_pk PRIMARY KEY  (id)
);

-- Table: cab_ride_status
CREATE TABLE cab_ride_status (
    id uniqueidentifier  NOT NULL,
    cab_ride_id uniqueidentifier  NOT NULL,
    status_time datetime  NOT NULL,
    status_cab_ride_id uniqueidentifier  NOT NULL,
    CONSTRAINT cab_ride_status_pk PRIMARY KEY  (id)
);

-- Table: driver
CREATE TABLE driver (
    id uniqueidentifier  NOT NULL,
    first_name varchar(128)  NOT NULL,
    last_name varchar(128)  NOT NULL,
    birth_date date  NOT NULL,
    driving_licence_number varchar(128)  NOT NULL,
    expiry_date date  NOT NULL,
    working bit  NOT NULL DEFAULT 1,
    CONSTRAINT driver_ak_1 UNIQUE (driving_licence_number),
    CONSTRAINT driver_pk PRIMARY KEY  (id)
);

-- Table: payment_type
CREATE TABLE payment_type (
    id uniqueidentifier  NOT NULL,
    type_name varchar(128)  NOT NULL,
    CONSTRAINT payment_type_ak_1 UNIQUE (type_name),
    CONSTRAINT payment_type_pk PRIMARY KEY  (id)
);

-- Table: shift
CREATE TABLE shift (
    id uniqueidentifier  NOT NULL,
    driver_id uniqueidentifier  NOT NULL,
    cab_id uniqueidentifier  NOT NULL,
    shift_start_time datetime  NULL,
    shift_end_time datetime  NULL,
    CONSTRAINT shift_pk PRIMARY KEY  (id)
);

-- Table: status_cab_ride
CREATE TABLE status_cab_ride (
    id uniqueidentifier  NOT NULL,
    staus_name varchar(25)  NOT NULL,
    CONSTRAINT status_cab_ride_pk PRIMARY KEY  (id)
);

-- foreign keys
-- Reference: cab_ride_payment_type (table: cab_ride)
ALTER TABLE cab_ride ADD CONSTRAINT cab_ride_payment_type
    FOREIGN KEY (payment_type_id)
    REFERENCES payment_type (id)
    ON UPDATE  CASCADE;

-- Reference: cab_ride_shift (table: cab_ride)
ALTER TABLE cab_ride ADD CONSTRAINT cab_ride_shift
    FOREIGN KEY (shift_id)
    REFERENCES shift (id)
    ON DELETE  CASCADE 
    ON UPDATE  CASCADE;

-- Reference: cab_ride_status_cab_ride (table: cab_ride_status)
ALTER TABLE cab_ride_status ADD CONSTRAINT cab_ride_status_cab_ride
    FOREIGN KEY (cab_ride_id)
    REFERENCES cab_ride (id)
    ON DELETE  CASCADE 
    ON UPDATE  CASCADE;

-- Reference: cab_ride_status_status_cab_ride (table: cab_ride_status)
ALTER TABLE cab_ride_status ADD CONSTRAINT cab_ride_status_status_cab_ride
    FOREIGN KEY (status_cab_ride_id)
    REFERENCES status_cab_ride (id);

-- Reference: drives_cab (table: shift)
ALTER TABLE shift ADD CONSTRAINT drives_cab
    FOREIGN KEY (cab_id)
    REFERENCES cab (id)
    ON DELETE  CASCADE 
    ON UPDATE  CASCADE;

-- Reference: drives_driver (table: shift)
ALTER TABLE shift ADD CONSTRAINT drives_driver
    FOREIGN KEY (driver_id)
    REFERENCES driver (id)
    ON DELETE  CASCADE 
    ON UPDATE  CASCADE;

-- End of file.

