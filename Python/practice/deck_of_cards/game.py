from classes.deck import Deck
from classes.card import Card
import random


# bicycle = Deck()

# bicycle.show_cards()

player_cards = []
dealer_cards = []

player_score = 0
dealer_score = 0


while len(player_cards) < 2:
    player_card = random.choice(Deck)
    player_score.append(player_card)
    Deck.remove(player_card)

print("Wecome to BlackJack")
