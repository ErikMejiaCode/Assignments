class Ninja {
    constructor(name, health, speed=3, strength=3) {
        this.name = name;
        this.health = health;
        this.speed = speed;
        this.strength = strength;
    }

    sayName(){
        return `The ninjas name is: ${this.name}`;
    }

    showStats(){
        return `Ninja name: ${this.name} strength: ${this.strength} speed: ${this.speed} and health: ${this.health}`
    }

    drinkSake(){
        return `Increasing health by 10. new health is: ${this.health += 10}`;
    }
}

const ninja1 = new Ninja("Hyabusa", 100);
const ninja2 = new Ninja("Erik", 200);
const ninja3 = new Ninja("Nalle", 150);
console.log(ninja1.sayName());
console.log(ninja1.showStats());
console.log(ninja1.drinkSake());
console.log(ninja1.showStats());
