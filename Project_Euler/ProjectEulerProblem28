# Problem 28:
"""What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?"""
# Corners always increase by multiples of 2 every four corners. Ex. 1(center), 3,5,7,9,13,17,21,25,etc...
def spiral_Sum(size):
    diag = [1]
    for i in range(2,size,2):
        for j in range(0,4):
            diag.append(diag[len(diag)-1]+i)
    return sum(diag)
