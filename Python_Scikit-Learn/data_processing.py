import arff, numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split

def loadArff2():
    dataset = arff.load(open('training2.arff', 'r'))
    data_input = np.array(dataset['data'])
    np.random.shuffle(data_input)
    data_attributes = np.array(dataset['attributes'][0:47])
    numrows = len(data_input)    
    numcols = len(data_input[0]) 
    dataf = pd.DataFrame(data_input[:,0:(numcols - 1)], columns=data_attributes[:(numcols - 1),0])
    target_input = np.array(data_input[:,(numcols - 1)], dtype=np.int)
    targetf = pd.DataFrame(target_input, columns=['Sonuc'])
    return dataf, targetf

#we use cross validation for testing
def prepapare_train_test(dataf, targetf):
    sX_train, sX_test, sy_train, sy_test = train_test_split(dataf, targetf, test_size=0.3, random_state=0, shuffle=True)
    return sX_train, sX_test, sy_train, sy_test
