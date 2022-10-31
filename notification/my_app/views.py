from django.shortcuts import render
from django.http import HttpResponse


# Create your views here.
def index(request):
    return HttpResponse("THIS IS A VIEW INSIDE MY APP")


def index2(request):
    return HttpResponse("THIS IS A 2 VIEW INSIDE MY APP")
