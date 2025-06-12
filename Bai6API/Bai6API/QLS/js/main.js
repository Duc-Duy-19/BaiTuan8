document.addEventListener('DOMContentLoaded', function () {
    fetchProducts();
    document.getElementById('btnAdd').addEventListener('click', addProduct);

    // Gắn sự kiện cho các nút trong bảng
    document.getElementById('productList').addEventListener('click', function (e) {
        const productId = e.target.getAttribute('data-id');
        if (e.target.classList.contains('view-btn')) {
            fetchProductById(productId);
        } else if (e.target.classList.contains('edit-btn')) {
            loadProductToForm(productId);
        } else if (e.target.classList.contains('delete-btn')) {
            if (confirm('Bạn có chắc muốn xóa sản phẩm này không?')) {
                deleteProduct(productId);
            }
        }
    });
});

const apiUrl = 'http://localhost:5277/api/products'; // Định nghĩa apiUrl chung

function fetchProducts() {
    fetch(apiUrl)
        .then(handleResponse)
        .then(data => displayProducts(data))
        .catch(error => console.error('Fetch error:', error.message));
}

// Handle fetch response, check for error, and parse JSON
function handleResponse(response) {
    if (!response.ok) throw new Error('Network response was not ok');
    return response.json();
}

// Display products in the HTML table
function displayProducts(products) {
    const bookList = document.getElementById('productList');
    bookList.innerHTML = ''; // Clear existing products
    products.forEach(product => {
        bookList.innerHTML += createProductRow(product);
    });
}

// Create HTML table row for a product
function createProductRow(product) {
    return `
        <tr>
            <td>${product.id}</td>
            <td>${product.name}</td>
            <td>${product.price}</td>
            <td>${product.description}</td>
            <td>
                <button class="btn btn-danger delete-btn" data-id="${product.id}">Delete</button>
                <button class="btn btn-warning edit-btn" data-id="${product.id}">Edit</button>
                <button class="btn btn-primary view-btn" data-id="${product.id}">View</button>
            </td>
        </tr>
    `;
}

// Add a new product
function addProduct() {
    const name = document.getElementById('bookName').value;
    const price = document.getElementById('price').value;
    const description = document.getElementById('description').value;

    if (!name || !price || !description) {
        alert('Vui lòng điền đầy đủ thông tin!');
        return;
    }
    if (isNaN(price)) {
        alert('Giá phải là số!');
        return;
    }

    const productData = {
        name: name,
        price: parseFloat(price),
        description: description,
    };

    fetch(apiUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(productData),
    })
    .then(response => {
        if (!response.ok) {
            return response.text().then(text => {
                throw new Error(`Network response was not ok: ${response.status} - ${text}`);
            });
        }
        return response.json();
    })
    .then(data => {
        console.log('Product added:', data);
        fetchProducts(); // Refresh the product list
        document.getElementById('studentForm').reset(); // Reset form
        alert('Thêm sản phẩm thành công!');
    })
    .catch(error => {
        console.error('Error:', error);
        alert('Có lỗi xảy ra khi thêm sản phẩm: ' + error.message);
    });
}

// Lấy thông tin chi tiết sản phẩm (GET by ID)
function fetchProductById(productId) {
    fetch(`${apiUrl}/${productId}`)
        .then(handleResponse)
        .then(product => {
            showProductDetail(product); // Hiển thị chi tiết trong modal
        })
        .catch(error => console.error('Error:', error));
}

// Hiển thị thông tin chi tiết trong modal
function showProductDetail(product) {
    document.querySelector('.modal-title').textContent = 'Thông tin chi tiết sách';
    document.querySelector('.fullName').textContent = product.name;
    document.querySelector('.code').textContent = product.id;
    document.querySelector('.dateOfBirth').textContent = product.name;
    document.querySelector('.gender').textContent = product.description;
    $('#modalViewDetailInfo').modal('show'); // Dùng jQuery để mở modal
}

// Cập nhật thông tin sản phẩm (PUT)
function updateProduct(productId) {
    const updatedProduct = {
        id: productId,
        name: document.getElementById('bookName').value,
        price: parseFloat(document.getElementById('price').value),
        description: document.getElementById('description').value,
    };

    fetch(`${apiUrl}/${productId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedProduct),
    })
    .then(response => {
        if (response.status === 204 || response.status === 200) {
            console.log('Product updated successfully.');
            fetchProducts(); // Refresh the product list
            document.getElementById('studentForm').reset(); // Reset form
            document.getElementById('btnAdd').style.display = 'inline-block'; // Hiện nút Add
            document.getElementById('btnUpdate').style.display = 'none'; // Ẩn nút Update
        } else {
            console.error('Failed to update product.');
        }
    })
    .catch(error => console.error('Error:', error));
}

// Điền dữ liệu sản phẩm vào form để chỉnh sửa
document.getElementById('productList').addEventListener('click', function (e) {
    const productId = e.target.getAttribute('data-id');
    
    // Kiểm tra xem productId có tồn tại và hợp lệ không
    if (!productId || isNaN(productId)) {
        alert("ID sản phẩm không hợp lệ!");
        return;
    }

    if (e.target.classList.contains('view-btn')) {
        fetchProductById(productId);
    } else if (e.target.classList.contains('edit-btn')) {
        loadProductToForm(productId);
    } else if (e.target.classList.contains('delete-btn')) {
        // Chỉ giữ lại một lần xác nhận ở đây
        if (confirm('Bạn có chắc muốn xóa sản phẩm này không?')) {
            deleteProduct(productId);
        }
    }
});

// Hàm deleteProduct đã loại bỏ lần xác nhận thứ hai
function deleteProduct(productId) {
    // Gửi yêu cầu DELETE đến API
    fetch(`http://localhost:5277/api/products/${productId}`, {
        method: "DELETE",
    })
        .then(response => {
            // Kiểm tra các mã trạng thái phản hồi
            if (response.status === 204) {
                alert("Xóa sản phẩm thành công!");
                fetchProducts(); // Làm mới danh sách sản phẩm
            } else if (response.status === 404) {
                alert("Xóa sản phẩm thành công!");
            } else if (response.status === 500) {
                alert("Lỗi server, vui lòng thử lại sau!");
            } else {
                // Lấy thông tin lỗi chi tiết từ phản hồi
                return response.text().then(text => {
                    throw new Error(`Xóa thất bại: ${response.status} - ${text}`);
                });
            }
        })
        .catch(error => {
            // Xử lý lỗi mạng hoặc CORS
            console.error("Lỗi khi xóa sản phẩm:", error);
            alert("Có lỗi xảy ra: " + error.message);
        });
}