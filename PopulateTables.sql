
-- Logins
INSERT INTO Administrator (admin_id, admin_username, admin_password, question_one_id, question_two_id, question_three_id, admin_isBlocked) VALUES (1,'Administrator', 'Password123', 1, 2, 3, 0);
INSERT INTO Question (question_id, question_question, answer) VALUES(1, 'What is your favorite NFL team?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(2, 'What is your nickname?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(3, 'In what town was your first job?', 'Answer');
INSERT INTO Administrator (admin_id, admin_username, admin_password, question_one_id, question_two_id, question_three_id, admin_isBlocked) VALUES (2,'marclowe', 'Password123', 4, 5, 6, 0);
INSERT INTO Question (question_id, question_question, answer) VALUES(4, 'What is the mascot of your undergraduate university?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(5, 'What year did you graduate high school?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(6, 'What year were you born?', 'Answer');

-- Credit cards and accounts
INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Shirley', 'Allison', '13975 Branford Street, Newark, NJ 07103', '7326190982', 10000, 5430.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4532889997304540', 'Shirley', 'Addison', '06', '2019', '107', 1);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4539954239968900', 'Michael', 'Addison', '06', '2019', '209', 1);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4532843460665230', 'Megan', 'Addison', '06', '2019', '742', 1);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Joanne', 'Adams', '1890 Claremont Avenue, Bloomfield, NJ 07003', '9736545785', 8700, 1200.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('5583616464279770', 'Joanne', 'Adams', '10', '2018', '634', 2);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('5542177792952520', 'Lucy', 'Adams', '10', '2018', '556', 2);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('William', 'James', '231 Elmwood Road, Verona, NJ 07004', '2016920793', 6000, 0.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('5489295193268860', 'William', 'James', '01', '2019', '827', 3);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Delores', 'Bensen', 'N1884 Clifton Avenue, Rego Park, NJ 07657', '2016204957', 21000, 12450.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011063674425120', 'Delores', 'Bensen', '04', '2019', '860', 4);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011963356904050', 'Paul', 'Bensen', '04', '2019', '307', 4);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011849224039700', 'Michael', 'Bensen', '04', '2019', '157', 4);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011256980059840', 'Sona', 'Bensen', '04', '2019', '248', 4);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011306598062290', 'Walker', 'Bensen', '04', '2019', '276', 4);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Martha', 'Wilkinson', '718 Academy Road, Caldwell, NJ 07006', '2016393784', 5000, 4000.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011484905656480', 'Martha', 'Wilkinson', '11', '2018', '449', 5);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Brian', 'Goldorf', '90 Peterson Street, River Edge, NJ 07661', '2016220909', 5000, 350.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('5369224925625610', 'Brian', 'Goldorf', '11', '2018', '657', 6);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Kimberly', 'Briggs', '457 Waukeesan Street, Wayne, NJ 07470', '8626448118', 6000, 1025.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('5122230446763830', 'Kimberly', 'Briggs', '06', '2018', '318', 7);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Thomas', 'Cooper', '8 Henning Drive, Fairfield, NJ 07004', '9736278003', 15000, 11975.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011564289227310', 'Thomas', 'Cooper', '02', '2019', '804', 8);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011866701361350', 'Glenn', 'Cooper', '02', '2019', '756', 8);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011306602934070', 'Parker', 'Cooper', '02', '2019', '197', 8);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('6011980021784770', 'George', 'Cooper', '02', '2019', '456', 8);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Erica', 'Cobb', '6385 Grove Road, South Orange, NJ 07079', '9736781785', 10000, 435.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4532806154779540', 'Erica', 'Cobb', '01', '2020', '578', 9);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4929330632306370', 'Richard', 'Cobb', '01', '2020', '185', 9);

INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Clement', 'Sanderson', '4 James Madison Avenue, Teaneck, NJ 07082', '9736672761', 13000, 7650.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4024007131459420', 'Clement', 'Sanderson', '03', '2020', '100', 10);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4539954239968900', 'Tom', 'Sanderson', '03', '2020', '924', 10);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4556724898301760', 'Robert', 'Sanderson', '03', '2020', '246', 10);

-- Processing center and gateways
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.200', 1, 0, null, 100);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.1', 1, 1, 'One', 2);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.4', 1, 1, 'Two', 4);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.5', 1, 1, 'Three', 4);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.8', 1, 1, 'Four', 3);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.11', 1, 1, 'Five', 4);
-- Relays
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.2', 1, 0, 'Two', 2);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.3', 1, 0, 'Two', 3);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.6', 1, 0, 'Three', 3);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.7', 1, 0, 'Three', 3);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.9', 1, 0, 'Five', 3);
INSERT INTO RelayStation(station_id, station_isActive, isGateway, region, queueLimit) VALUES('192.168.0.10', 1, 0, 'Five', 3);
-- Stores
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.101', 'JC Penney', 'One');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.102', 'Sears', 'One');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.103', 'Herbergers', 'One');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.104', 'Macys', 'One');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.105', 'Macys', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.106', 'Nordstorm', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.107', 'Target', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.108', 'Walmart', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.109', 'Boston Store', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.110', 'Verizon', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.111', 'Best Buy', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.112', 'Whole Foods', 'Two');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.113', 'Sears', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.114', 'Target', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.115', 'Verizon', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.116', 'H&M', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.117', 'Banana Republic', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.118', 'Best Buy', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.119', 'Walmart', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.120', 'Nordstorm', 'Three');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.121', 'JC Penney', 'Four');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.122', 'Macys', 'Four');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.123', 'Target', 'Four');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.124', 'Walmart', 'Four');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.125', 'JC Penney', 'Five');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.126', 'Sears', 'Five');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.127', 'Herbergers', 'Five');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.128', 'Macys', 'Five');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.129', 'Target', 'Five');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.130', 'Walmart', 'Five');	
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.131', 'Verizon', 'Five');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.132', 'Best Buy', 'Five');
INSERT INTO Store(store_id, store_name, region) VALUES('192.168.0.133', 'Walmart', 'Five');
--Connect gateways to processing center
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.200', '192.168.0.4', 1, 12);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.200', '192.168.0.11', 1, 10);
--Connect relays to other relays in same region
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.1', '192.168.0.5', 1, 7);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.2', '192.168.0.3', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.2', '192.168.0.4', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.3', '192.168.0.4', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.4', '192.168.0.8', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.6', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.7', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.1', 1, 7);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.8', 1, 10);	
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.11', 1, 10);	
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.6', '192.168.0.7', 1, 4);	
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.9', '192.168.0.10', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.9', '192.168.0.11', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.10', '192.168.0.11', 1, 4);
--Connect stores to relays
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.1', '192.168.0.101', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.1', '192.168.0.102', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.1', '192.168.0.103', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.1', '192.168.0.104', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.2', '192.168.0.105', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.2', '192.168.0.106', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.2', '192.168.0.107', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.2', '192.168.0.108', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.3', '192.168.0.108', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.3', '192.168.0.109', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.3', '192.168.0.110', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.4', '192.168.0.108', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.4', '192.168.0.111', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.4', '192.168.0.112', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.113', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.114', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.115', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.116', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.5', '192.168.0.118', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.6', '192.168.0.113', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.6', '192.168.0.117', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.6', '192.168.0.118', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.6', '192.168.0.119', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.7', '192.168.0.115', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.7', '192.168.0.116', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.7', '192.168.0.118', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.7', '192.168.0.119', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.7', '192.168.0.120', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.8', '192.168.0.121', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.8', '192.168.0.122', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.8', '192.168.0.123', 1, 5);	
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.8', '192.168.0.124', 1, 4);	
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.9', '192.168.0.125', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.9', '192.168.0.126', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.9', '192.168.0.127', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.9', '192.168.0.128', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.9', '192.168.0.129', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.10', '192.168.0.128', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.10', '192.168.0.130', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.10', '192.168.0.131', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.10', '192.168.0.132', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.10', '192.168.0.133', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.11', '192.168.0.127', 1, 4);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.11', '192.168.0.128', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.11', '192.168.0.129', 1, 3);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.11', '192.168.0.130', 1, 5);
INSERT INTO Connection(station_one_id, station_two_id, connection_isActive, weight) VALUES ('192.168.0.11', '192.168.0.131', 1, 3);