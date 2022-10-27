class User:
    def __init__(self, first_name, last_name, email, age):
        self.first_name = first_name
        self.last_name = last_name
        self.email = email
        self.age = age
        self.is_reward_member = False
        self.gold_card_points = 0

    def display_info(self):
        print(f" First name: {self.first_name} \n Last Name: {self.last_name} \n Email: {self.email} \n Age: {self.age} \n Reward Member: {self.is_reward_member} \n Gold Points: {self.gold_card_points}")
        return self

    def enroll(self):
        self.is_reward_member = True
        self.gold_card_points = 200
        print(f" {self.first_name} is now a member and reflects a status of {self.is_reward_member}.")
        print(f" {self.first_name}'s points have been update. They now reflect {self.gold_card_points} points.")
        return self

    def spend_points(self,amount):
        self.gold_card_points -= amount
        print(f" {self.first_name} has spent {amount} points. They now reflect a balance of {self.gold_card_points} points.")
        return self

user1 = User("Erik", "Mejia", "email@gamil.com", 28)
user2 = User("Nallely", "Escobedo", "nayay7@yahoo.com", 28)

user1.display_info().enroll().spend_points(50).display_info()
user2.display_info().enroll().spend_points(80).display_info()