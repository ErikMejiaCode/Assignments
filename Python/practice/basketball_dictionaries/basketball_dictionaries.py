# Create your Player instances here!
# player_jason = ???

# class Player:
#     def __init__(self, name, age, position, team):
#         self.name = name
#         self.age = age
#         self.position = position
#         self.team = team

class Player:
    def __init__(self, data):
        self.name = data["name"]
        self.age = data["age"]
        self.position = data["position"]
        self.team = data["team"]

    @classmethod
    def get_teams(cls, team_list):
        player_objects = []
        for dictionaries in players:
            player_objects.append(cls(dictionaries))
        return player_objects


    # Not required for the assignment but useful
#     # __repr__(self) is a python system method that 
#     # tells python how to handle representing that class 
#     # when, for example the object is printed to the terminal.
#     def __repr__(self):
#         display = f"Player: {self.name}, {self.age} y/o, pos: {self.position}, team: {self.team}"
#         return display

players = [
    {
    "name": "Kevin Durant", 
    "age":34, 
    "position": "small forward", 
    "team": "Brooklyn Nets"
    },
    {
    "name": "Jason Tatum", 
    "age":24, 
    "position": "small forward", 
    "team": "Boston Celtics"
    },
    {
    "name": "Kyrie Irving", 
    "age":32,
    "position": "Point Guard", 
    "team": "Brooklyn Nets"
    },
    {
    "name": "Damian Lillard", 
    "age":33,
    "position": "Point Guard", 
    "team": "Portland Trailblazers"
    },
    {
    "name": "Joel Embiid", 
    "age":32,
    "position": "Power Foward", 
    "team": "Philidelphia 76ers"
    },
    {
    "name": "DeMar DeRozan",
    "age": 32,
    "position": "Shooting Guard",
    "team": "Chicago Bulls"
    }
]


kevin = {
    "name": "Kevin Durant", 
    "age":34, 
    "position": "small forward", 
    "team": "Brooklyn Nets"
}
jason = {
    "name": "Jason Tatum", 
    "age":24, 
    "position": "small forward", 
    "team": "Boston Celtics"
}
kyrie = {
    "name": "Kyrie Irving", 
    "age":32,
    "position": "Point Guard", 
    "team": "Brooklyn Nets"
}
    
# Create your Player instances here!
# player_jason = ???

player_kevin = Player(kevin["name"], kevin["age"], kevin["position"], kevin["team"])
player_jason = Player(jason["name"], jason["age"], jason["position"], jason["team"])
player_kyrie = Player(kyrie["name"], kyrie["age"], kyrie["position"], kyrie["team"])

print(player_jason.age)
print(player_kevin.position)
print(player_kyrie.team)

# player_kevin = Player(kevin)
# player_jason = Player(jason)
# player_kyrie = Player(kyrie)

# print(player_jason.age)
# print(player_kevin.position)
# print(player_kyrie.team)