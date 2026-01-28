document.addEventListener('DOMContentLoaded', () => {
  const form = document.getElementById('registerForm');
  const message = document.getElementById('message');

  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    message.textContent = '';
    const fd = new FormData(form);
    const username = fd.get('username');
    const password = fd.get('password');
    const confirm = fd.get('confirm');

    if (!username || !password) {
      message.textContent = 'Please fill all fields.';
      return;
    }
    if (password !== confirm) {
      message.textContent = 'Passwords do not match.';
      return;
    }

    try {
      const res = await fetch('/api/auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
      });

      if (res.ok) {
        // After register, redirect to login
        window.location.href = '/login.html';
      } else {
        message.textContent = 'Registration failed.';
      }
    } catch (err) {
      message.textContent = 'Network error.';
    }
  });
});
