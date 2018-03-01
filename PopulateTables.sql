INSERT INTO Administrator (admin_id, admin_username, admin_password, question_one_id, question_two_id, question_three_id, admin_isBlocked) VALUES (1,'Administrator', 'Password123', 1, 2, 3, 0);
INSERT INTO Question (question_id, question_question, answer) VALUES(1, 'What is your favorite NFL team?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(2, 'What is your nickname?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(3, 'In what town was your first job?', 'Answer');
INSERT INTO Administrator (admin_id, admin_username, admin_password, question_one_id, question_two_id, question_three_id, admin_isBlocked) VALUES (2,'marclowe', 'Password123', 4, 5, 6, 0);
INSERT INTO Question (question_id, question_question, answer) VALUES(4, 'What is the mascot of your undergraduate university?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(5, 'What year did you graduate high school?', 'Answer');
INSERT INTO Question (question_id, question_question, answer) VALUES(6, 'What year were you born?', 'Answer');
INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('James', 'Aldridge', '187 North Main Street Apt.4, La Crosse, WI 54601', '6085550123', 25000, 0.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4916937470822873', 'James', 'Aldridge', 4, 18, '693', 1);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4539511779921483', 'Cameron', 'Aldridge', 7, 18, '349', 1);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('3599729064660729', 'Devin', 'Aldridge', 10, 19, '437', 1);
INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Gabriella', 'Lambert', '1725 State Street, La Crosse, WI 54601', '6085554567', 20000, 0.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4024007152937081', 'Gabriella', 'Lambert', 6, 19, '339', 2);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4716210473532382', 'Wyatt', 'Lambert', 7, 19, '350', 2);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4916170736135852', 'Haley', 'Lambert', 3, 19, '168', 2);
INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('McCullough', 'Carole', '3167 Franklin Avenue, Nelson, NH 03457', '6039698862', 15000, 0.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4716477993656484', 'Carole', 'McCullough', 7, 19, '342', 3);
INSERT INTO Account (account_holder_firstname, account_holder_lastname, account_address, account_phone, account_limit, account_balance) VALUES('Adams', 'Darrell', '4402 Hedge Street, Piscataway NJ 08854', '9084066387', 22000, 0.0);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('5538572760352094', 'Darrell', 'Adams', 8, 21, '758', 4);
INSERT INTO Card(card_id, card_firstname, card_lastname, card_expirationMonth, card_expirationYear, card_securityCode, account_id) VALUES('4485228863864370', 'Dalton', 'Lily', 7, 18, '259', 4);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.1', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.2', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.3', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.4', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.5', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.6', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.7', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.8', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.9', 1);
INSERT INTO RelayStation(station_id, station_isActive) VALUES('192.168.0.10', 1);
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.100', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.101', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.102', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.103', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.104', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.105', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.106', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.107', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.108', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.109', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.110', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.111', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.112', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.113', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.114', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.115', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.116', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.117', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.118', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.119', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.120', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.121', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.122', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.123', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.124', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.125', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.126', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.127', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.128', 'Store Name');
INSERT INTO Store(store_id, store_name) VALUES('192.168.0.129', 'Store Name');