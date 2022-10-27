// GIVEN
console.log(example);
var example = "I'm the example!";
// AFTER HOISTING BY THE INTERPRETER
// var example;
// console.log(example); // logs undefined
// example = "I'm the example!";

//1
console.log(hello);
var hello = 'world';
//var hello;
//console.log(hello); will log undefined

//2
var needle = 'haystack'; //assigning a value to the global 'needle'
test(); //test is called
function test(){ //function test is hoisted to the top
    var needle = 'magnet'; //value is assigned to the scope 'needle'
    console.log(needle); // we log it as magnet
}


//3
var brendan = 'super cool'; //assigning a value to the global 
function print(){ //function print is hoisted to the top
    brendan = 'only okay'; //value is assigned to the in scope brendan 
    console.log(brendan); //we log it as 'only ok'
}
console.log(brendan); //log the global brendan 

//4
var food = 'chicken'; //assigning value to the global
console.log(food); //logging the global as chicken
eat(); //eat is called
function eat(){ //function e at is hoisted to the top
    food = 'half-chicken';//value is assigned to the in scope food 
    console.log(food);//we log it as 'half-chicken'
    var food = 'gone'; //assigning value in the scope
}

//5 
mean(); //function is called/hoisted to the top 
console.log(food); //error will populate as food is not defined globally 
var mean = function() { //function is never called 
    food = "chicken"; //value is assigned to the in scope food 
    console.log(food); //food is logged as chicken
    var food = "fish"; //assigning a value to the scope 
    console.log(food);
}
console.log(food);// error as food is not defined globally 

//6
console.log(genre);//console will run as undefined 
var genre = "disco";//assigning a value to the global 
rewind(); //function is called/hoisted to the top 
function rewind() { //function rewind is hoisted to the top
    genre = "rock"; //value is assigned to the in scope genre 
    console.log(genre); //genre is logged as rock
    var genre = "r&b"; //assigning value in the scope
    console.log(genre); //genre is logged as r&b
}
rewind()
console.log(genre);// error as food is not defined globally 

//7
dojo = "san jose"; //value is assigned as a global 
console.log(dojo); // dojo is logged as san jose
learn(); //function is called/hoisted to the top 
function learn() { //function rewind is hoisted to the top
    dojo = "seattle"; //value is assigned  in the scope
    console.log(dojo); // dojo is logged as seattle
    var dojo = "burbank";
    console.log(dojo);// dojo is logged as burbank
}
console.log(dojo);// dojo is logged as san jose

//8
console.log(makeDojo("Chicago", 65)); //reference error - make dojo is not defined
console.log(makeDojo("Berkeley", 0)); //reference error - make dojo is not defined
function makeDojo(name, students){ //function make dojo is hoisted to the top
    const dojo = {}; //value of object is assigned to dojo
    dojo.name = name; //property or dojo name
    dojo.students = students; //property or dojo students
    if(dojo.students > 50){
        dojo.hiring = true;
    }
    else if(dojo.students <= 0){
        dojo = "closed for now"; //error as dojo is a const and cannot be changed.
    }
    return dojo;
}
console.log(makeDojo("Chicago", 65)); //reference error - make dojo is not defined
console.log(makeDojo("Berkeley", 0)); 



