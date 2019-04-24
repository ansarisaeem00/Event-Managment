import zipfile

jungle_zip = zipfile.ZipFile('C:\Users\SUPER-COMPUTER.IS7\Desktop\Compression\comp.zip', 'w')
jungle_zip.write('Report.pdf', compress_type=zipfile.ZIP_DEFLATED)

jungle_zip.close()