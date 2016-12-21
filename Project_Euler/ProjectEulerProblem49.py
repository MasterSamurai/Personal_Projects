import math
from collections import Counter

def is_Prime(n):
    return not any([n % i == 0 for i in range(2, int(math.sqrt(n))+1)])

def prime_Distance_Sequence():
    p = [i for i in range(1488,10000) if is_Prime(i)]
    for i in p:
        if is_Prime(i+3330) and is_Prime(i+6660) and Counter(str(i)) == Counter(str(i+3330)) == Counter(str(i+6660)):
            return str(i) + str(i+3330) + str(i+6660)

print(prime_Distance_Sequence())
