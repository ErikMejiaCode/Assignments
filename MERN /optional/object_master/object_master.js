


const pokémon = Object.freeze([
    { "id": 1, "name": "Bulbasaur", "types": ["poison", "grass"] },
    { "id": 5, "name": "Charmeleon", "types": ["fire"] },
    { "id": 9, "name": "Blastoise", "types": ["water"] },
    { "id": 12, "name": "Butterfree", "types": ["bug", "flying"] },
    { "id": 16, "name": "Pidgey", "types": ["normal", "flying"] },
    { "id": 23, "name": "Ekans", "types": ["poison"] },
    { "id": 24, "name": "Arbok", "types": ["poison"] },
    { "id": 25, "name": "Pikachu", "types": ["electric"] },
    { "id": 37, "name": "Vulpix", "types": ["fire"] },
    { "id": 52, "name": "Meowth", "types": ["normal"] },
    { "id": 63, "name": "Abra", "types": ["psychic"] },
    { "id": 67, "name": "Machamp", "types": ["fighting"] },
    { "id": 72, "name": "Tentacool", "types": ["water", "poison"] },
    { "id": 74, "name": "Geodude", "types": ["rock", "ground"] },
    { "id": 87, "name": "Dewgong", "types": ["water", "ice"] },
    { "id": 98, "name": "Krabby", "types": ["water"] },
    { "id": 115, "name": "Kangaskhan", "types": ["normal"] },
    { "id": 122, "name": "Mr. Mime", "types": ["psychic"] },
    { "id": 133, "name": "Eevee", "types": ["normal"] },
    { "id": 144, "name": "Articuno", "types": ["ice", "flying"] },
    { "id": 145, "name": "Zapdos", "types": ["electric", "flying"] },
    { "id": 146, "name": "Moltres", "types": ["fire", "flying"] },
    { "id": 148, "name": "Dragonair", "types": ["dragon"] }
]);


const pokemonIdBy3 = pokémon.filter( id => id.id % 3 === 0);
console.log(pokemonIdBy3);
console.log("************************");

const fireType = pokémon.filter( type => type.types[0] == "fire");
console.log(fireType);
console.log("************************");

const typeMoreThanOne = pokémon.filter( type => type.types[0] && type.types[1]);
console.log(typeMoreThanOne);
console.log("************************");

const pokemonId99 = pokémon.filter( id => id.id > 99);
console.log(pokemonId99);
console.log("************************");

const pokemonNames = pokémon.map( name => name['name']);
console.log(pokemonNames);
console.log("************************");

const pokemonNamesPoison = pokémon.filter(type => type.types[0] == 'poison').map( name => name['name'])
console.log(pokemonNamesPoison);
console.log("************************");

const pokemonFlyingType = pokémon.filter(type => type.types[1] == 'flying').map( type => type.types[0])
console.log(pokemonFlyingType);
console.log("************************");

const pokemonNormal = pokémon.filter( type => type.types[0] == 'normal')
console.log(pokemonNormal.length);
console.log("************************");

