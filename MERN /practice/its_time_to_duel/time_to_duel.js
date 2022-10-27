class Card {
    constructor(name = '', cost = 0){
        this.name = name;
        this.cost = cost;
    }

displayCard(){
    let output = 
    "**********************************\n" +
    "name :" + this.name + "\n" +
    "cost: " + this.cost + "\n";

    return output;
}

}

class Unit extends Card {
    constructor(name= '', cost = 0, power = 0, resilience = 0) {
        super(name, cost)
        this.power = power;
        this.resilience = resilience;
    }

    displayCard(){
        let output = super.displayCard();
        output += "power: " + this.power + '\n' + "resilience: " + this.resilience;
        return output;
    }

    alterAttributes(effectCard){
        this[effectCard.stat] += effectCard.magnitude;
    }

    attack(target){
        target.alterAttributes({
            stat : 'resilience',
            magnitude : -this.power
        })
    }

}


class Effect extends Card {
    constructor(name='', cost=0, text='', stat='', magnitude=0){
        super(name, cost);
        this.text = text;
        this.stat = stat;
        this.magnitude = magnitude;
    }

    displayCard(){
        let output = super.displayCard();
        output += "text: " + this.text + '\n' + "stat: " + this.stat + '\n' + "magnitude: " + this.magnitude;
        return output;
    }
    
    playEffect(unitCard){
        unitCard.alterAttributes(this);
    }

}



const unitCard1 = new Unit("Red Belt Ninja", 3, 3, 4);
const unitCard2 = new Unit("Black Belt Ninja", 4, 5, 4);

const effectCard1 = new Effect("Hard Algorithm", 2, "increase target's resilience by 3","resilience", 3);
const effectCard2 = new Effect("Unhandled Promise Rejection ", 1, "reduce target's resilience by 2	","resilience", -2);
const effectCard3 = new Effect("Pair Programming ", 3, "increase target's power by 2","power", 2);



console.log(unitCard2.displayCard());
unitCard1.attack(unitCard2);
console.log(unitCard2.displayCard());
// console.log(effectCard1.displayCard());