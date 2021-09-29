function App() {

    selectFiles = (files) => {
        const file = files[0];
        const formData = new FormData();
        var name = file.name;
       // formData.append('file', file);
        formData.append('FileName', name);
        var xhr = new XMLHttpRequest();
        xhr.open("post", "api/UploadFile", true);
        xhr.onload =  function () {
            if (xhr.status === 200) {
                console.log(file.name);

            }
        }.bind(this);
        xhr.send(formData);
    }
    
    return <input type="file" onChange={(e) => this.selectFiles(e.target.files)}></input>;
    
}
ReactDOM.render(
    <App />,
    document.getElementById("content")
);