# -*- coding:utf-8 -*-

import os
import sys
import FileHelper
import StringHelper


def get_class_content(class_name):
	new_str = "export default class " + class_name + " {\r\n" + "\r\n}"
	
	return new_str


## 创建文件并写入内容
if __name__ == '__main__':
	source_path = "E:\LMSGame\wl\wlgame\wlgame\chient\Assets\Main\Scripts"
	target_path = "E:\\LMSGit\\LMS\\Laya\\Client\\src\\GameClient\\"
	
	## 从外到内，递归遍历所有文件夹及文件
	for (root, dirs, files) in os.walk(source_path):
		for d in dirs:
			file_list = FileHelper.check_suffix(os.path.join(root, d), [".cs"])
			for fname in file_list:
				new_fname = StringHelper.cut_out_string_forward(fname, ".cs")
				new_fname = new_fname.replace('.', '_');
				
				new_f_path = StringHelper.cut_out_string_backward(new_fname, "\\Scripts\\")
				idx = StringHelper.get_find_backward(new_f_path, "\\") + 1
				new_f_name = new_f_path[idx:]
				
				new_f_path = target_path + new_f_path + ".ts"
				
				if not os.path.exists(new_f_path):
					FileHelper.make_file(new_f_path, get_class_content(new_f_name))
					print(new_f_path)
					
					
				
				
			
