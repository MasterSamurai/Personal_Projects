# Problem 15:
"""Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down,
there are exactly 6 routes to the bottom right corner. How many such routes are there through a 20×20 grid?"""
def factorial(number):
    new = 1
    for i in range(number,1,-1):
        new *= i
    return new

def find_paths(grid_height, grid_width):
    return (factorial(grid_height+grid_width)//factorial(grid_width))//factorial(grid_height)
