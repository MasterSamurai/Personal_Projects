# Problem 16:
"""What is the sum of the digits of the number 21000?"""
def sum_Of_Digits(number):
    digits = []
    for i in range(0,len(str(number))):
        digits.append(int(str(number)[i]))
    return sum([j for j in digits])
