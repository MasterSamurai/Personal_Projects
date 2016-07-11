# Problem 17:
"""If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?"""
def letter_Count(number):
    length, num = len(str(number)), str(number)
    ones, teens, tens, hundred, thousand = [0,3,3,5,4,4,3,5,5,4], [0,3,6,6,8,8,7,7,9,8,8], [0,3,6,6,5,5,5,7,6,6], 7, 8
    if length == 1:
        return ones[number]
    elif length == 2 and int(num[0]) == 1:
        return teens[int(num[1])+1]
    elif length == 2:
        return tens[int(num[0])] + ones[int(num[1])]
    elif length == 3 and int(num[1]) == 0 and int(num[2]) == 0:
        return ones[int(num[0])] + hundred
    elif length == 3 and int(num[1]) == 1:
        return ones[int(num[0])] + hundred + 3 + teens[int(num[2])+1]
    elif length == 3:
        return ones[int(num[0])] + hundred + 3 + tens[int(num[1])] + ones[int(num[2])]
    elif length == 4:
        return ones[int(num[0])] + thousand

def sum_Of_Letters(limit):
    return sum([letter_Count(i) for i in range(limit+1)])
