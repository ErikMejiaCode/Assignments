function pizzaOven(crustType, sauceType, cheeses, toppings) {
    var pizza = {
        crustType: ["deep dish", "flatbread", "hand tossed"],
        sauceType: ["traditional", "marinara", "no sauce"],
        cheeses: ["mozzarella", "feta", "provolone"],
        toppings: ["mushrooms", "pepperoni", "olives", "jalapenos", "onions", "pinneaple", "ham", "sausage"],
    };
    pizza.crustType = crustType;
    pizza.sauceType = sauceType;
    pizza.cheeses = cheeses;
    pizza.toppings = toppings;
    return pizza;
}

var p1 = pizzaOven("hand tossed", "marinara", ["mozzarella", "feta"], ["mushrooms", "olives", "onions"]);
console.log(p1);

