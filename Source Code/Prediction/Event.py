from flask import Flask, render_template, request
import os
from nltk.classify import NaiveBayesClassifier
import pandas as pd
from sklearn import linear_model


app = Flask(__name__)


@app.route('/')
def home():
    return render_template('Form.html')


def word_feats(words):
    return dict([(word, True) for word in words])


@app.route('/events', methods=['POST'])
def get_details():
    EventName = request.form.get('EventName')
    Rating = request.form.get('EventRating')
    Audience = request.form.get('Audience')
    Feedback = request.form.get('Feedback')
    print(EventName, Rating, Audience, Feedback)
    df = pd.read_csv('EventData.csv')
    print(df)
    positive_vocab = ['awesome', 'outstanding', 'fantastic', 'terrific', 'good', 'nice', 'great', ':)']
    negative_vocab = ['bad', 'terrible', 'useless', 'hate', ':(', 'improvement']
    neutral_vocab = ['movie', 'the', 'sound', 'was', 'is', 'actors', 'did', 'know', 'words', 'not']

    positive_features = [(word_feats(pos), 'pos') for pos in positive_vocab]
    negative_features = [(word_feats(neg), 'neg') for neg in negative_vocab]
    neutral_features = [(word_feats(neu), 'neu') for neu in neutral_vocab]

    train_set = negative_features + positive_features + neutral_features

    classifier = NaiveBayesClassifier.train(train_set)

    XTrainingData = df[['Rating', 'FeedBack', 'Audience']]
    YTrainingData = df['Success']

    reg = linear_model.LinearRegression()
    reg.fit(XTrainingData, YTrainingData)

    neg = 0
    pos = 0
    Rating = int(Rating)
    Audience = int(Audience)
    Feedback = Feedback.lower()
    words = Feedback.split(' ')
    for word in words:
        classResult = classifier.classify(word_feats(word))
        if classResult == 'neg':
            neg = neg + 1
        if classResult == 'pos':
            pos = pos + 1

    Feedback = float(pos) / len(words)
    Success = reg.predict([[Rating, Feedback, Audience]])
    print(Success)

    result = str(Success)
    data = {'Prediction' : result}
    return render_template('ShowResult.html', result = data)


if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=4000)
