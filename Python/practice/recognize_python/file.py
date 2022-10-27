
#variable declaration
#using numbers
num1 = 42
num2 = 2.3
#booleans
boolean = True
#strings
string = 'Hello World'
#lists - initialize
pizza_toppings = ['Pepperoni', 'Sausage', 'Jalepenos', 'Cheese', 'Olives']
#dictionary - initialize
person = {'name': 'John', 'location': 'Salt Lake', 'age': 37, 'is_balding': False}
#tuples - initialize
fruit = ('blueberry', 'strawberry', 'banana')
#log statement
print(type(fruit))
#log statement - printing the type of the fruit tuple
print(pizza_toppings[1])
#log statement - will print the topping in index 1 of the list = sausage
pizza_toppings.append('Mushrooms')
#adding to a list. appending is adding a value to the end of the list. 
print(person['name'])
#log statement - printing from a dictionary using the person as the key.
person['name'] = 'George'
#changing value in a dictionary - changing value from name to George.
person['eye_color'] = 'blue'
#add value - adding new value to a dictionary. adding a new value of eye color to blue.
print(fruit[2])
#log statement - loging the value of index 2 of fruit

if num1 > 45:
# conditional if statement - declaration
    print("It's greater")
    #log statment 
else:
#conditional else statement 
    print("It's lower")
    #log statement

if len(string) < 5:
#using the the len function to check the length of something
    print("It's a short word!")
    #log statement
elif len(string) > 15:
#conventional elif statement - using the len function as well
    print("It's a long word!")
    #log statement 
else:
#conventional else statement.
    print("Just right!")
    #log statement 
for x in range(5):
#conventional for satatement - start 
    print(x)
    #log statement 
for x in range(2,5):
    print(x)
    #log statement 
for x in range(2,10,3):
    print(x)
    #log statement 
x = 0
#while loop start 
while(x < 5):
    print(x)
    x += 1

pizza_toppings.pop()
#pop function will remove the last value in a list
pizza_toppings.pop(1)
#pop with a number will remove the value at that index

print(person)
#log command 
person.pop('eye_color')
#removing the eye_color from the person key using the pop function
print(person)

#for loop start 
for topping in pizza_toppings:
    #conditional if statement
    if topping == 'Pepperoni':
        continue
    print('After 1st if statement')
    #conditional if statement
    if topping == 'Olives':
        break

def print_hello_ten_times():
    for num in range(10):
        print('Hello')

print_hello_ten_times()

def print_hello_x_times(x):
    for num in range(x):
        print('Hello')

print_hello_x_times(4)

def print_hello_x_or_ten_times(x = 10):
    for num in range(x):
        print('Hello')

print_hello_x_or_ten_times()
print_hello_x_or_ten_times(4)


"""
#mutiline comment 
Bonus section
"""

# print(num3)
# num3 = 72
# fruit[0] = 'cranberry'
# print(person['favorite_team'])
# print(pizza_toppings[7])
#   print(boolean)
# fruit.append('raspberry')
# fruit.pop(1)