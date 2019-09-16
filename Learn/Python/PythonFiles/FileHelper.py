# -*- coding:utf-8 -*-
import os
import sys

## 从内到外，递归遍历，删除空的文件夹	
## path = 文件夹路径
def remove_null_folder(path):
	for (root, dirs, files) in os.walk(path, topdown=False):
		if not files and not dirs:
			print(root)
			os.rmdir(root)
		
			
## 递归创建文件夹，忽略文件夹已存在的报错。
## path = 文件夹路径
def make_dirs(path):
	try:
		os.makedirs(path)
	except OSError:
		if not os.path.isdir(path):
			raise

## 创建文件，并写入内容。如果文件已存在，则忽略。
## path = 文件夹路径
## content = 要写入的内容
def make_file(path, content):
	if not os.path.exists(path):
		f = open(path,'w')
		f.write(content)
		f.close
		



## 从外到内，递归遍历，文件夹及文件
def for_folder_files():
	for (root, dirs, files) in os.walk(path):
		for d in dirs:
			cut_path = cut_out_string(os.path.join(root, d))
			print(os.path.join(t_path, cut_path))
		
			
## 检查指定的文件夹下的文件后缀，是否存在于 condition_format 数组中。
## path = 文件夹路径
## condition_format = [".cs"]
## 返回筛选后，条件满足的文件数组
def check_suffix(path, condition_format):
	file_list = []
	for filename in os.listdir(path):
		if os.path.splitext(filename)[1] in condition_format:
			#print(os.path.join(path,filename))
			file_list.append(os.path.join(path,filename))
	
	return file_list























