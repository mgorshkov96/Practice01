import subprocess
import time

subprocess.run(['python', 'value_generator.py'])

python_file = 'python_dgemm.py'
java_file = 'java_dgemm/src/benchmark/JavaDgemm.java'
csharp_file = 'Csharp.Dgemm/Csharp.Dgemm/bin/Debug/Csharp.Dgemm.exe'

subprocess.run([java_file])


#stdout_data = p.communicate(input=fname.encode())[0]

# timings = {}
# inputs = {'imdb_data5pct.txt': 3515346 / BYTES_IN_MIB,
#           'imdb_data10pct.txt': 6759264 / BYTES_IN_MIB,
#           'imdb_data20pct.txt': 14116119 / BYTES_IN_MIB,
#           'imdb_data40pct.txt': 27514274 / BYTES_IN_MIB}
# for fname in inputs.keys():
#     start_time = time.time()
#     p = Popen(['python', 'find_names_list.py'], stdout=PIPE, stdin=PIPE, stderr=PIPE)
#     stdout_data = p.communicate(input=fname.encode())[0]
#     #output = subprocess.run(['python', 'find_names_list.py'], capture_output=True)
#     #print(stdout_data)
#     end_time = time.time()
#     timings[fname] = end_time-start_time
# print(timings)