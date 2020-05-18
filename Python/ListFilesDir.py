import os
import fnmatch
import glob
from pathlib import Path

for filename in os.listdir(r'C:\Root\Training\Python'):
    if fnmatch.fnmatch(filename, '*.py'):
         print(filename)

for f_name in os.listdir(r'C:\Root\Training\Python'):
     if f_name.endswith('.txt'):
         print(f_name)


for name in glob.glob('*[aA-zZ]*.log'):
     print(name)


p = Path(r'C:\Root\Training\Python')
for name in p.glob('*.txt'):
     print(name)