
var _DanhMuc =
{
    LoadList: function () {
        $.ajax({
            url: 'Index',
            method: 'GET',
            success: function (data) {
                $('#ngu').append(data);
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
            }
        });
    },
    ShowModalUpdate: function (id) {
        $.ajax({
            url: 'Update',
            method: 'POST',
            data: { id: id },
            success: function (data) {
                $('#exampleModal').addClass('show');
                $('#MaNhaCc').value = data.MaNhaCc
                $('#TenNhaCc').value = data.TenNhaCc
                $('#DiaChi').value = data.DiaChi
                $('#DienThoai').value = data.DienThoai
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
            }
        });
    }
    ,

    UpdateObj: function () {
        let obj =
        {
            "MaNhaCc": $("#MaNhaCc").val(),
            "TenNhaCc": $("#TenNhaCc").val(),
            "DiaChi": $("#DiaChi").val(),
            "DienThoai": $("#DienThoai").val()
        }
        $.ajax({
            url: 'UpdateNhaCc',
            method: 'POST',
            data: { obj: obj },
            success: function (data) {
                if (data.success) {
                    alert("Cập nhật thành công!");
                } else {
                    alert("Cập nhật thất bại!");
                }
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
            }
        });
    },
    AddNhacc: function () {
        let obj =
        {
            "MaNhaCc": $("#MaNhaCc").val(),
            "TenNhaCc": $("#TenNhaCc").val(),
            "DiaChi": $("#DiaChi").val(),
            "DienThoai": $("#DienThoai").val()
        }
        $.ajax({
            url: 'Add',
            method: 'POST',
            data: { obj: obj },
            success: function (data) {
                alert("Them thành công!");
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
            }
        });
    }
}
