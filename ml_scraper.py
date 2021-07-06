import requests
import argparse
import csv
from bs4 import BeautifulSoup

def process_page(url: str, csv_w: csv):
    page = requests.get(url)

    soup = BeautifulSoup(page.content, "html.parser")
    result = soup.find("ol", class_="ui-search-layout ui-search-layout--stack")

    items_result = result.find_all("li", class_="ui-search-layout__item")

    for item in items_result:
        title = item.find("h2", class_="ui-search-item__title").text.strip()
        link = item.find("a", class_="ui-search-item__group__element ui-search-link")['href']
        price = item.find("span", class_="price-tag-fraction").text.strip()
        price = price.replace('.','')
        print(title, end=" : ")
        print(price, end= " : ")
        print(link, end= "\n")
        csv_w.writerow([title, price, link])
    return

url = "https://listado.mercadolibre.com.ar/"

parser = argparse.ArgumentParser()
parser.add_argument('search', default='telefonos-celulares')
parser.add_argument('-url', , action='store_true')
parser.add_argument('-p_min', type=int, default=0)
parser.add_argument('-p_max', type=int, default=0)
parser.add_argument('-new', action='store_true')
parser.add_argument('-used', action='store_true')
parser.add_argument('-area', default='')
parser.add_argument('-depth', type=int, default=0)

args = parser.parse_args()
if args.url:
    url = args.search
else:
    if args.new and not args.used:
        url+="nuevo/"
    elif not args.new and args.used:
        url+="usado/"
    url += args.search.replace(" ", "-")
    if args.p_min > 0 or args.p_max > 0:
        url+="_PriceRange_"+str(args.p_min)+"-"+str(args.p_max)+"_"

file_out = open("output.csv", "w", newline='' )
file_out.write('')
csv_w = csv.writer(file_out)


print(url)
#process_page(url, csv_w)

if args.depth >> 0:
    for i in range(args.depth):
        num = 50*i+1
        process_page(url+'_Desde_'+str(num), csv_w)