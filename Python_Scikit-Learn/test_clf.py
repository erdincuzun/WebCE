from results import *
from sklearn.linear_model import SGDClassifier
from sklearn.linear_model import LogisticRegression
from sklearn.neural_network import MLPClassifier
from sklearn.neighbors import KNeighborsClassifier
from sklearn.svm import SVC
from sklearn.gaussian_process import GaussianProcessClassifier
from sklearn.gaussian_process.kernels import RBF
from sklearn.tree import DecisionTreeClassifier
from sklearn.ensemble import RandomForestClassifier, AdaBoostClassifier
from sklearn.naive_bayes import GaussianNB
from sklearn.discriminant_analysis import QuadraticDiscriminantAnalysis
import time
from sklearn.model_selection import cross_val_predict

from sklearn.utils.class_weight import compute_sample_weight

names = ["Nearest Neighbors", "Nearest Neighbors Distance", 
         "Decision Tree", "Decision Tree Balanced", 
         "Random Forest", "Random Forest Balanced", 
         "AdaBoost",  "AdaBoost Balanced",
         "Logistic Regression", "Logistic Regression Balanced", 
         "Neural Net", "Naive Bayes", "QDA"]
#"Linear SVM", "RBF SVM", 
classifiers = [    
    KNeighborsClassifier(),
    KNeighborsClassifier(weights='distance'),
    DecisionTreeClassifier(), #max_depth=None
    DecisionTreeClassifier(class_weight='balanced'), #max_depth=None
    RandomForestClassifier(),#max_depth=None, n_estimators=10, max_features=1
    RandomForestClassifier(class_weight='balanced'),#max_depth=None, n_estimators=10, max_features=1
    AdaBoostClassifier(),
    AdaBoostClassifier(DecisionTreeClassifier(class_weight='balanced')),
    LogisticRegression(),
    LogisticRegression(class_weight='balanced'),
    MLPClassifier(), #alpha=1    
    GaussianNB(),
    QuadraticDiscriminantAnalysis()]

#too slow
#SVC(kernel="linear", C=0.025),
#SVC(gamma=2, C=1),

#low f-measure

def start_classifiers_test(X_train, X_test, y_train, y_test, testno):
    for name, clf in zip(names, classifiers):
        print('----------------------------------------------------------------')
        start1 = time.time()
        model = clf.fit(X=X_train, y=y_train) # algoritma için model oluşturuluyor
        end1 = time.time()
        start2 = time.time()
        y_pred = model.predict(X_test) #tahmin sonuçları listede
        end2 = time.time()
        #show_results(y_test, y_pred, name) #liste mevcut liste ile kıyaslanıyor.
        
        print('----------------------------------------------------------------')
        print(name)
        print(testno)
        print('Model Time: ' + str(end1 - start1))
        print('Prediction Time: ' + str(end2 - start2))
        write_results(y_test, y_pred, testno + ',' + name, str(end1 - start1) + ',' + str(end2 - start2),  "classification_results.txt")
        print('----------------------------------------------------------------')

def start_classifiers_cv_test(dataf, labels, testno):
    for name, clf in zip(names, classifiers):
        print(name)
        start1 = time.time()
        predicted = cross_val_predict(clf, dataf, labels, cv=10)
        end1 = time.time()
        write_results(labels, predicted, testno + ',' + name, str(end1 - start1),  "classification_cv_results.txt")