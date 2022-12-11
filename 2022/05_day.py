import math

def move_stacks(instr, mat, flag):

    rep_num = int(instr[0])
    start_stack = int(instr[1])
    end_stack = int(instr[2])

    if flag is False:   #first part
        for x in range(rep_num):
            popped = mat[start_stack-1].pop()
            mat[end_stack-1].append(popped)

    else:               #second part
        l = len(mat[end_stack-1])
        for x in range(rep_num):
            popped = mat[start_stack-1].pop()
            mat[end_stack-1].insert(l, popped)   

    return mat


def print_top_stack(mat):
    result = ""
    for stack in mat:
        result += (stack[-1])
    
    print (result)



with open("05_input.txt", "r") as file:
    data = []
    while True:
        line = file.readline()
        if(line == ""):
            break        
        line = line[:-1]

        if "move" in line:
            line = line.replace("move", " ")
            line = line.replace("from", " ")
            line = line.replace("to", " ")

            instruction = line.split(" ")
            aux = instruction.copy()
            for x in instruction:
                if x == "":
                    aux.remove(x)
            instruction = aux.copy()


            #mat = move_stacks(instruction, mat, False)  #first part
            mat = move_stacks(instruction, mat, True)   #second part

        else:
            if (line.find("[_]")):            
                skip = 0
                for y in line:
                    if (y == "[" or y == "]"):
                            continue
                    if (y == " "):
                        skip +=1
                        if (skip == 4):
                            data.append(".")
                            skip = 0
                    else:
                        data.append(y)
                        skip = 0
        
            lenght = len(data)
            r = int(math.sqrt(lenght))
            mat = []      
            for x in range (1, r+1):
                x = []
                mat.append(x)

            index = 0
            # loop over data, fill mat accordingly
            for val in data:
                if val != ".":
                    vert_index = index % r
                    mat[vert_index].insert(0, val)
                index += 1

            for x in mat:
                x.pop(0)
              

              
    print_top_stack(mat)
file.close()
