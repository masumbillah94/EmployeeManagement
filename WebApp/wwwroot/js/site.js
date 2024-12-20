// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const baseUrl = "https://localhost:7275/api/";

function CallApi(method, endpoint, data, success, error) {
    if (method.toLowerCase() === 'get') {
        const queryString = objectToQueryParams(data);
        const urlWithParams = queryString ? baseUrl + endpoint + "?" + queryString : baseUrl + endpoint;

        $.ajax({
            type: "GET",
            url: urlWithParams,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                success(data)
            },
            failure: function (data) {
                error(data)
            },
            error: function (data) {
                error(data)
            }

        });
    } else {
        $.ajax({
            type: method,
            url: baseUrl + endpoint,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data),
            success: function (data) {
                success(data);
            },
            failure: function (data) {
                error(data);
            },
            error: function (data) {
                error(data);
            }
        });
    }
}

function objectToQueryParams(obj) {
    const params = new URLSearchParams();
    for (const key in obj) {
        if (obj.hasOwnProperty(key) && obj[key] != null) {
            params.append(key, obj[key]);
        }
    }
    return params.toString();
}