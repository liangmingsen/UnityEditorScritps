from  BaseHTTPServer import HTTPServer,BaseHTTPRequestHandler
import urllib
import json
import time

import sys
reload(sys)
sys.setdefaultencoding( "utf-8" )

data = {'result': 'ok'}

class ServerHTTP(BaseHTTPRequestHandler):
    def do_GET(self):
        self.send_response(200)
        self.send_header('Content-type', 'application/json')
        self.end_headers()
        self.wfile.write(json.dumps(data).encode())
        
    def do_POST(self):
        path = self.path
        print path
        datas = self.rfile.read(int(self.headers['content-length']))
        datas = urllib.unquote(datas).decode("utf-8", 'ignore')
        print(datas)
        f = open('logs.txt', 'a')
        ''' f.write("\n\n" + time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time())) + "\n") ''' 
        f.write('\n' + datas)
        f.close()
        self.send_response(200)
        self.send_header('Content-type', 'application/json')
        self.end_headers()
        self.wfile.write(json.dumps(data).encode())

if __name__ == '__main__':
    http_server = HTTPServer(('', int(8000)), ServerHTTP)
    http_server.serve_forever()