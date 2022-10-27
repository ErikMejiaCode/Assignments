INSERT INTO users (first_name, last_name)
VALUES ('Jane', 'Amsden'), 
('Emily', 'Dixon'), 
('Theodore', 'Destoevsky'), 
('William', 'Shapiro'), 
('Lao', 'Xiu');

INSERT INTO books (title)
VALUES ('C Sharp'), 
('Java'), 
('Python'), 
('PHP'), 
('Ruby');

SELECT * FROM books;
SELECT * FROM users;
SELECT * FROM favorites;

UPDATE books
SET title = 'C#'
WHERE title = 'C Sharp';

UPDATE users
SET first_name = 'Bill'
WHERE users.id = 4;

INSERT INTO favorites (user_id, book_id)
VALUES (1,1), (1,2);

INSERT INTO favorites (user_id, book_id)
VALUES (2,1), (2,2), (2,3);

INSERT INTO favorites (user_id, book_id)
VALUES (3,1), (3,2), (3,3),(3,4);

INSERT INTO favorites (user_id, book_id)
VALUES (4,1), (4,2), (4,3),(4,4), (4,5);

SELECT id, first_name, last_name 
FROM users
JOIN favorites ON users.id = favorites.user_id
WHERE favorites.book_id = 3;

DELETE FROM favorites 
WHERE user_id = 2 AND book_id = 3;

INSERT INTO favorites (user_id, book_id)
VALUES (5,2);

SELECT * FROM books
JOIN favorites ON books.id = favorites.book_id
WHERE favorites.book_id = 5;

SELECT * FROM users
JOIN favorites ON favorites.user_id = users.id
WHERE favorites.book_id = 5;



