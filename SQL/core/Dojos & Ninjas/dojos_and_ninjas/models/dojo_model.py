from dojos_and_ninjas.config.mysqlconnection import connectToMySQL
from dojos_and_ninjas import DATABASE
from dojos_and_ninjas.models import ninja_model

class Dojo:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
    # Now we use class methods to query our database


    @classmethod
    def get_all(cls):
        query = 'SELECT * FROM dojos;'
    # make sure to call the connectToMySQL function with the schema you are targeting.
        results = connectToMySQL(DATABASE).query_db(query)
    # Create an empty list to append our instances of friends
        dojos = []
    # Iterate over the db results and create instances of friends with cls.
        for dojo in results:
            dojos.append(cls(dojo))
        return dojos


    @classmethod
    def new_dojo(cls, data):
        query = "INSERT INTO dojos (name) VALUES (%(name)s);"
        result = connectToMySQL(DATABASE).query_db(query, data)
        return result


    @classmethod
    def one_dojo(cls, data):
        query = 'SELECT * FROM dojos LEFT JOIN ninjas ON dojos.id = ninjas.dojo_id WHERE dojos.id = %(id)s'
        results = connectToMySQL(DATABASE).query_db(query, data)
        print(results)
        if results:
            dojo_instance = cls(results[0])
            ninjas_list = []
            for row_from_db in results:
                ninja_data = {
                    'id' : row_from_db['ninjas.id'],
                    'dojo_id' : row_from_db['dojo_id'],
                    'first_name' : row_from_db['first_name'],
                    'last_name' : row_from_db['last_name'],
                    'age' : row_from_db['age'],
                    'created_at' : row_from_db['ninjas.created_at'],
                    'updated_at' : row_from_db['ninjas.updated_at']
                }
                ninja_instance = ninja_model.Ninja(ninja_data)
                ninjas_list.append(ninja_instance)
            dojo_instance.ninjas = ninjas_list
            return dojo_instance
        return results


    @classmethod
    def update(cls, data):
        query = 'UPDATE dojos SET first_name = %(name)s WHERE id = %(id)s;'
        return connectToMySQL(DATABASE).query_db(query, data)

    @classmethod
    def delete(cl, data):
        query = 'DELETE FROM dojos WHERE id = %(id)s;'
        return connectToMySQL(DATABASE).query_db(query, data)
