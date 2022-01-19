# ProjetStock  - Projet Tristan/Hossein

![alt text](https://comparebrokers.co/img/ai-trader.jpg)
## Table of Contents
1. [Presentation](#Présentation)
    -  [Details](#Details)
    -  [Avantages](#Avantages)
    -  [Compléxité](#Compléxité)
2. [Images](#Images)
3. [Schema](#Schema)
    -  [UML](#Details)
    -  [Storyboard](#Storyboard)
4. [Installation](#Installation )


# Présentation

##### Details
Le projet permet de gérer les informations sur les actions de différentes bourses.
Il se compose des phases suivantes :
- (phase 1- décidée pour le moment)
Afficher les différentes variations de la valeur des stocks au fil du temps à travers des tableaux qui montrent les changements au cours d'une même journée, une semaine, un mois et 6 mois
- (phase 2 - Facultatif) Ajout d'un bot pour le trading automatique avec définition de prix par le client
- (phase 3- facultative) Ajouter d'un agent NLP qui fournit les 10 informations connexes les plus importantes pour le client en fonction de ses choix pour les actions
- (phase4 - Facultatif) Ajouter d'un système de recommandation qui permet d'analyser les informations fournies par le système NLP en plus d'analyser les informations en fonction de chaque action et de définir l'intérêt possible et le niveau du risque pour une durée prédéfinie , pour le commerce , par le client
- L'application a une API CRUD avec une connexion JWT (bearer).


------------


#####  Avantages
1. Un système pour garder les informations des actions en fonction de durée différentes pour comparer les variations de valeur par rapport à plusieurs métriques.
2. Une interface dynamique et personnalisée en fonction des choix de l'utilisateur
3. Liste d'actions dynamique et personnalisable par le client
4. Gérer les infor	mations en continu et il envoie des notifications  de rappel par email/sms

------------


##### Compléxité
1. Mise à jour des informations par rapport a la liste dynamique.
2. Le virement est liée aux vendeurs et aux acheteurs d'actions ( en temps réel) . Puis, il faut faire la mise à jour de la base de données
3. Mise à jour de la base de données par rapport à des données en temps réel.
4. Responsive design pour le site web ( utilisation de Boostrap ou tailwindcss)


##### [Document Word](https://view.officeapps.live.com/op/view.aspx?src=https%3A%2F%2Fraw.githubusercontent.com%2FPOEC-DOTNET-CLERMONT-2022%2FProjetStock%2Fmain%2FDocuments%2Fprojet%2520POEC%2520-%2520logiciel%2520vente%2520ou%2520achat%2520action.odt&wdOrigin=BROWSELINK)
------------

# Images:
Non disponible pour le moment
------------
# Schema

##### UML
###### Usecase :
![alt text](https://raw.githubusercontent.com/POEC-DOTNET-CLERMONT-2022/ProjetStock/main/Documents/UML/Use_Case_Stock_Projet.jpg)

###### Diagramme de classe
![alt text](https://raw.githubusercontent.com/POEC-DOTNET-CLERMONT-2022/ProjetStock/main/Documents/UML/Diagram_Stock_Projet.jpg)
------------
##### Storyboard
##### [Download]
------------
# Installation
 - Mise en place de la base de données
 - Mise en place du serveur 
