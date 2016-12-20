import math

alphabet = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]

def wordValue(word):
    return sum([alphabet.index(letter) + 1 for letter in word])

def isTriangle(num):
    return math.sqrt(num*8 + 1).is_integer()

def triangleWords():
    words = open('words.txt', 'r', encoding="utf-8").read().lower().replace('"','').split(sep=',')
    return sum([1 for word in words if isTriangle(wordValue(word))])

print(triangleWords())
