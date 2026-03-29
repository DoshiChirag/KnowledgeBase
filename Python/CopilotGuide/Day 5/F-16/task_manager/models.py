class Task:
    def __init__(self, task_id, title, description, completed=False, due_date=None):
        self.task_id = task_id
        self.title = title
        self.description = description
        self.completed = completed
        self.due_date = due_date

    def __repr__(self):
        return f"Task(id={self.task_id}, title='{self.title}', description='{self.description}', completed={self.completed}, due_date={self.due_date})"