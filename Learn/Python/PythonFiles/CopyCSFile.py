import sys
import os

cd_file_list = [];

def find_cs_file(path):
	global cd_file_list
	f_list = os.listdir(path)
	for i in f_list:
		print("path ==> " + os.path.splitext(i))
	

if __name__ == '__main__':
	currrent_work_dir = os.path.abspath("./")
	print("---start copy ---" + currrent_work_dir)
	
	f_list = os.listdir(currrent_work_dir)
	for i in f_list:
		print("path ==> " + os.path.splitext(i))
	
	# find_cs_file(currrent_work_dir)
	
