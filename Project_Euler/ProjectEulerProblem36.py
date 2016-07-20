# Problem 36:
"""Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2."""
def doubleBasePalindromes(limit):
    return sum([i for i in range(1,limit) if str(bin(i)).replace('0b','') == str(bin(i)).replace('0b','')[::-1] and i == int(str(i)[::-1])])
