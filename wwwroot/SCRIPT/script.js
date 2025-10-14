const menuItems = document.querySelectorAll('.menu-item');

menuItems.forEach(item => {
    item.addEventListener('click', () => {
        // Remove a classe "active" de todos
        menuItems.forEach(el => el.classList.remove('active'));
        // Adiciona ao item clicado
        item.classList.add('active');
    });
});

/* cadastro cliente */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simulação de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usuário ou senha inválidos.");
    }
});

/* cadastro fornecedor */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simulação de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usuário ou senha inválidos.");
    }
});

/* Cadastro Produto */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simulação de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usuário ou senha inválidos.");
    }
});

/* Cadastro Serviço */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simulação de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usuário ou senha inválidos.");
    }
});
/*hora*/
<script>
    function updateClock() {
        const now = new Date();
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
    const seconds = String(now.getSeconds()).padStart(2, '0');
    document.getElementById('clock').textContent = `${hours}:${minutes}:${seconds}`;
    }
    setInterval(updateClock, 1000);
    updateClock();
</script>