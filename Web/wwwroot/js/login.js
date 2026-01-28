document.addEventListener('DOMContentLoaded', () => {
  const form = document.getElementById('loginForm');
  const message = document.getElementById('message');

  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    message.textContent = '';
    const fd = new FormData(form);
    const payload = {
      username: fd.get('username'),
      password: fd.get('password')
    };

    try {
      const res = await fetch('/api/auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });

      if (res.ok) {
        const data = await res.json();
        localStorage.setItem('revija_token', data.token);
        localStorage.setItem('revija_user', data.username);
        window.location.href = '/';
      } else if (res.status === 401) {
        message.textContent = 'Invalid username or password.';
      } else {
        message.textContent = 'Login failed.';
      }
    } catch (err) {
      message.textContent = 'Network error.';
    }
  });
});
