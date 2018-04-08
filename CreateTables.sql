
CREATE TABLE Account(account_id int IDENTITY(1,1) PRIMARY KEY, account_holder_firstname varchar(15), account_holder_lastname varchar(15), account_address varchar(100), account_phone varchar(10), account_limit int, account_balance float);
CREATE TABLE Card(card_id varchar(16) PRIMARY KEY, card_firstname varchar(15), card_lastname varchar(15), card_expirationMonth varchar(2), card_expirationYear varchar(4), card_securityCode varchar(3), account_id int);
CREATE TABLE Administrator(admin_id varchar(10) PRIMARY KEY, admin_username varchar(32), admin_password varchar(32), question_one_id varchar(10), question_two_id varchar(10), question_three_id varchar(10), admin_isBlocked bit);
CREATE TABLE Question(question_id varchar(10) PRIMARY KEY, question_question varchar(100), answer varchar(50));
CREATE TABLE Transactions(trans_id int IDENTITY(1,1) PRIMARY KEY, card_id varchar(16), store_id varchar(15), trans_date datetime, trans_amount float, trans_category varchar(20), trans_status bit, response_id varchar(10), status_time datetime, encrypted bit);
CREATE TABLE Response(response_id int IDENTITY(1,1) PRIMARY KEY, trans_id varchar(10), store_id varchar(15), response_date datetime, status bit);
CREATE TABLE RelayStation(station_id varchar(15) PRIMARY KEY, station_isActive bit, isGateway bit, region varchar(30), queueLimit int);
CREATE TABLE Connection(station_one_id varchar(15), station_two_id varchar(15), connection_isActive bit, weight int);
CREATE TABLE Store(store_id varchar(15) PRIMARY KEY, store_name varchar(30), region varchar(30));