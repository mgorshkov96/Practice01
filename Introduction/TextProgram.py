n1 = input("Enter the first number: ")
n2 = input("Enter the second number: ")
n3 = float(n1) + float(n2)
print(n1 + " plus " + n2 + " = ", n3)

a = 1/3
print("{:7.3f}".format(a))
a = 2/3
b = 2/9
print("{:7.3f} {:7.3f}".format(a, b))
print("{:10.3e} {:10.3e}".format(a, b))

n1 = input("Enter the first number: ")
n2 = input("Enter the second number: ")
n3 = float(n1) + float(n2)
print("{} plus {} = {}".format(n1, n2, n3))

list1 = [82,8,23,97,92,44,17,39,11,12]
# dir(list)
# help(list.insert)
# help(list.append)
# help(list.sort)
# help(list.remove)
# help(list.reverse)
list1[0] = 4
print(list1)
list1.append(100500)
print(list1)
list1.insert(5,77)
print(list1)
list1.pop(0)
print(list1)
list1.pop()
print(list1)

list1.sort(reverse = True)
print(list1)
list2 = [3,5,6,2,33,6,11]
list3 = sorted(list2)
print(list2)
print(list3)

# dir(tuple)
# help(tuple.index)
# help(tuple.count)

seq = (2,8,23,97,92,44,17,39,11,12)
print(seq.count(8))
print(seq.index(44))
listseq = list(seq)
print(type(listseq))
listseq.insert(7,0)
print(listseq)

D = {"food": "Apple", "quantity": "4", "color": "red"}
D["food"] = "Banana"
print(D)
dp = {"name": input("Введите имя: "), "age": input("Введите возраст: ")}
print(dp)

rec = {"name": {"firstname": "Bob", "lastname": "Smith"},
       "job": ["dev", "mgr"],
       "age": 25}
print(rec["name"])
print(rec["name"]["firstname"])
print(rec["job"])
rec["job"].append("janitor")
print(rec)