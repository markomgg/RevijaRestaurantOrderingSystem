document.addEventListener('DOMContentLoaded', async () => {
  const list = document.getElementById('ordersList');
  const res = await fetch('/api/orders');
  if (!res.ok) { list.textContent = 'Failed to load orders.'; return; }
  const orders = await res.json();
  if (orders.length === 0) { list.textContent = 'No orders yet.'; return; }
  orders.forEach(o => {
    const li = document.createElement('li');
    li.textContent = `#${o.orderId} — ${o.status} — ${o.totalPrice} MKD`;
    list.appendChild(li);
  });
});
