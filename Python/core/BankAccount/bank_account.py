

class BankAccount:

    account_instances = []
    # don't forget to add some default values for these parameters!
    def __init__(self, int_rate, balance=0): 
        self.int_rate = int_rate
        self.balance = balance
        BankAccount.account_instances.append(self)
        # your code here! (remember, instance attributes go here)
        # don't worry about user info here; we'll involve the User class soon

    def deposit(self, amount):
        self.balance += amount
        print(f"You have deposited an amount of ${amount}, your total account reflects a balance of ${self.balance}")
        return self


    def withdraw(self, amount):
        if self.balance > amount:
            self.balance -= amount
            print(f"You have withdrawn ${amount} from your account. Your remaining balance is ${self.balance}.")
            return self
        else:
            self.balance -= 5
            print(f"Insufficient funds: Charging a $5 fee. Your balance is now ${self.balance}")
            return self

    def display_account_info(self):
        print(f"Your account balance is ${self.balance}")
        return self

    def yield_interest(self):
        self.int_rate = self.balance * self.int_rate
        self.balance = self.balance + self.int_rate
        print(f"Your interest amount is ${self.int_rate}. Adding that to your account, your balance becomes ${self.balance}.")
        return self
    
    @classmethod
    def print_all_bank_instances(cls):
        for bank in cls.account_instances:
            bank.display_account_info()


bank_account1 = BankAccount(.03, 1000)
bank_account2 = BankAccount(.02, 500)

bank_account1.deposit(100).deposit(100).deposit(200).withdraw(200).display_account_info()

bank_account2.deposit(200).deposit(200).withdraw(100).withdraw(100).withdraw(100).withdraw(200).yield_interest().display_account_info()

# BankAccount.print_all_bank_instances()