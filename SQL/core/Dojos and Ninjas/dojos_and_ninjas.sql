SELECT * FROM dojos;

INSERT INTO dojos (name)
VALUES ('Wasabi Warriors'), ('Red Dragon'), ('Karate Kids');

DELETE FROM dojos
WHERE dojos.id BETWEEN 1 and 3;

INSERT INTO dojos (name)
VALUES ('Wasabi Warriors'), ('Red Dragon'), ('Karate Kids');

INSERT INTO ninjas (first_name, last_name, age, dojo_id)
VALUES ('Jack', 'Jack', '17', '5'),
('Kim', 'Kim', '16', '5'),
('Rudy', 'Rudy', '24', '5');

SELECT * FROM ninjas;

INSERT INTO ninjas (first_name, last_name, age, dojo_id)
VALUES ('Milton', 'Milton', '17', '6'),
('Grace', 'Grace', '16', '6'),
('Daemon', 'Daemon', '24', '6');

SELECT * FROM ninjas 
JOIN dojos ON dojos.id = ninjas.dojo_id
WHERE dojos.id = 3;

SELECT * FROM dojos
JOIN ninjas ON dojos.id = ninjas.dojo_id
WHERE dojos.id = 6;

SELECT * FROM ninjas
JOIN dojos ON dojos.id = ninjas.dojo_id
WHERE ninjas.id = 6;