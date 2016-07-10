# Problem 13
"""Work out the first ten digits of the sum of the following one-hundred 50-digit numbers."""
def sum_Digits(file, num_Digits):
    nums = list(open(file, 'r', encoding='utf-8', newline=None))
    return str(sum(i for i in [int(str.replace(',', "")) for str in nums]))[:num_Digits]
