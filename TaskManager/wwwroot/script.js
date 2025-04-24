document.addEventListener('DOMContentLoaded', () => {

    // Base URL of your API
    const API_BASE_URL = '/api';

    // Theme Toggle
    document.getElementById('theme-toggle').addEventListener('click', () => {
        const body = document.body;
        body.classList.toggle('dark-theme');
        body.classList.toggle('light-theme');
        const themeButton = document.getElementById('theme-toggle');
        themeButton.textContent = body.classList.contains('dark-theme') ? 'Switch to Light Theme' : 'Switch to Dark Theme';
    });

    // Load Notes
    document.getElementById('load-notes').addEventListener('click', async () => {
        const response = await fetch(`${API_BASE_URL}/Notes`);
        const notes = await response.json();
        const notesList = document.getElementById('notes-list');
        notesList.innerHTML = '';
        notes.forEach(note => {
            const li = document.createElement('li');
            li.textContent = `${note.title}: ${note.content} (${note.category})`;
            notesList.appendChild(li);
        });
    });

    // Create a Note
    document.getElementById('create-note-form').addEventListener('submit', async (e) => {
        e.preventDefault();
        const title = document.getElementById('note-title').value;
        const content = document.getElementById('note-content').value;
        const category = document.getElementById('note-category').value;

        const response = await fetch(`${API_BASE_URL}/Notes`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, content, category })
        });

        if (response.ok) {
            alert('Note created successfully!');
            document.getElementById('create-note-form').reset();
        } else {
            alert('Failed to create note.');
        }
    });

    // Edit Note
    async function editNotePrompt(id, title, content, category) {
        const newTitle = prompt('Edit Title:', title);
        const newContent = prompt('Edit Content:', content);
        const newCategory = prompt('Edit Category:', category);

        if (newTitle && newContent && newCategory) {
            const response = await fetch(`${API_BASE_URL}/Notes/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id, title: newTitle, content: newContent, category: newCategory })
            });

            if (response.ok) {
                alert('Note updated successfully!');
            } else {
                alert('Failed to update note.');
            }
        }
    }

    // Delete Note
    async function deleteNote(id) {
        const response = await fetch(`${API_BASE_URL}/Notes/${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            alert('Note deleted successfully!');
        } else {
            alert('Failed to delete note.');
        }
    }


    // Load Tasks
    document.getElementById('load-tasks').addEventListener('click', async () => {
        const response = await fetch(`${API_BASE_URL}/Tasks`);
        const tasks = await response.json();
        const tasksList = document.getElementById('tasks-list');
        tasksList.innerHTML = '';
        tasks.forEach(task => {
            const li = document.createElement('li');
            li.textContent = `${task.title}: ${task.description} (Due: ${task.dueDate})`;
            tasksList.appendChild(li);
        });
    });

    // Create a Task
    document.getElementById('create-task-form').addEventListener('submit', async (e) => {
        e.preventDefault();
        const title = document.getElementById('task-title').value;
        const description = document.getElementById('task-description').value;
        const dueDate = document.getElementById('task-due-date').value;

        const response = await fetch(`${API_BASE_URL}/Tasks`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, description, dueDate })
        });

        if (response.ok) {
            alert('Task created successfully!');
            document.getElementById('create-task-form').reset();
        } else {
            alert('Failed to create task.');
        }
    });

    document.getElementById('load-notes').addEventListener('click', async () => {
        const response = await fetch('/api/Notes');
        const notes = await response.json();
        const notesList = document.getElementById('notes-list');
        notesList.innerHTML = '';
        notes.forEach(note => {
            const li = document.createElement('li');
            li.textContent = `${note.title}: ${note.content} (${note.category})`;
            notesList.appendChild(li);
        });
    });

    // Edit Task
    async function editTaskPrompt(id, title, description, dueDate) {
        const newTitle = prompt('Edit Title:', title);
        const newDescription = prompt('Edit Description:', description);
        const newDueDate = prompt('Edit Due Date:', dueDate);

        if (newTitle && newDescription && newDueDate) {
            const response = await fetch(`${API_BASE_URL}/Tasks/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id, title: newTitle, description: newDescription, dueDate: newDueDate })
            });

            if (response.ok) {
                alert('Task updated successfully!');
            } else {
                alert('Failed to update task.');
            }
        }
    }

    // Delete Task
    async function deleteTask(id) {
        const response = await fetch(`${API_BASE_URL}/Tasks/${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            alert('Task deleted successfully!');
        } else {
            alert('Failed to delete task.');
        }
    }
});
