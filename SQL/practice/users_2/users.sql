INSERT INTO users (first_name, last_name, email)
VALUES ('Erik', 'Mejia', 'erik@gamil.com'), ('Nay','Escobedo','nay@gamil.com'),
('Jair', 'Merjia', 'ahauh@hauha.com');

SELECT * FROM users
ORDER BY first_name DESC;

SELECT first_name, last_name
FROM users
WHERE email = 'erik@gamil.com';

SELECT first_name, last_name, email
FROM users
WHERE users.id = 3;

UPDATE users
SET last_name = 'Pancakes'
WHERE users.id = 3;

DELETE FROM users WHERE users.id = 2;