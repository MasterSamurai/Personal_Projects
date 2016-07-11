# Problem 22:
"""What is the total of all the name scores in the file?"""
def name_Score(file):
    names = list(open(file, 'r', encoding='utf-8', newline=None))
    names = sorted(names[0].split(','))
    alphabet, sum = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'], 0
    for name in names:
        score = 0
        for l in name:
            if l != '"':
                score += alphabet.index(l)+1
        sum += score*(names.index(name)+1)
    return sum
