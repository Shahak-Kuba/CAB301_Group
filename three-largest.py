import math
import time
import random
import csv

count = 5
rand_arr = []
for i in range(count):
    rand_arr.append(random.randint(-10, 10))

print(rand_arr)

def threeLargest(A):
    counter = 0
    L = [-math.inf, -math.inf, -math.inf]
    counter += 1 # Assign L
    for i in range(len(A)):
        if A[i] > L[0]:
            L[2] = L[1]
            L[1] = L[0]
            L[0] = A[i]
            counter += 4 # 3 assignments, 1 greater than check
        elif A[i] > L[1]:
            L[2] = L[1]
            L[1] = A[i]
            counter += 4 # 2 assignments, 2 greater than checks
        elif A[i] > L[2]:
            L[2] = A[i]
            counter += 4 # 1 assignments, 3 greater than checks
        counter += 3 # 3 greater than checks
    counter += 1 # Return statement
    return counter

start_time = time.process_time()

min = -1000
max = 1000
bacthes = 10
epochs = 26
increment = 40000
basic_operations = []
for i in range(epochs):
    print(f"Processing: {i} / {epochs}")
    sum = 0
    for j in range(bacthes):
        A = []
        for k in range(increment * i):
            A.append(random.randint(min, max))
        sum += threeLargest(A)
    basic_operations.append(sum/bacthes)

for bo in basic_operations:
    print(bo)

print(f"\nTime: {time.process_time() - start_time}")

with open('./time2.csv', 'w') as f:
    write = csv.writer(f, lineterminator='\n')
    for i in range(len(basic_operations)):
        write.writerow([increment*i, basic_operations[i]])
   # write.writerows(([row] for row in basic_operations))
   
def threeLargestREAL(A):
    L = [-math.inf, -math.inf, -math.inf]
    for i in range(len(A)):
        if A[i] > L[0]:
            L[2] = L[1]
            L[1] = L[0]
            L[0] = A[i]
        elif A[i] > L[1]:
            L[2] = L[1]
            L[1] = A[i]
        elif A[i] > L[2]:
            L[2] = A[i]
    return L