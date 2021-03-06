////function App() {

////    selectFiles = (files) => {
////        const file = files[0];
////        const formData = new FormData();
////        var name = file.name;
////        formData.append("FileName", name);
////        var xhr = new XMLHttpRequest(); 
////        xhr.open("post", "api/UploadFile", true);
////        xhr.onload = function () {
////            if (xhr.status === 200) {
////                console.log(file.name);

////            }
////        }.bind(this);
////        xhr.send(formData);
////    }

////    return <input type="file" onChange={(e) => this.selectFiles(e.target.files)}></input>;

////}
////ReactDOM.render(
////    <App />,
////    document.getElementById("content")
////);



class App extends React.Component {
	componentDidMount() {
		axios.get("api/uploadfile").then(resp => {

			console.log(resp.data);
		});
    }
	state = {

		// Initially, no file is selected
		selectedFile: null
	};

	// On file select (from the pop up)
	onFileChange = event => {

		// Update the state
		this.setState({ selectedFile: event.target.files[0] });
		event.target.value = '';
	};
	

	// On file upload (click the upload button)
	onFileUpload = () => {

		// Create an object of formData
		const formData = new FormData();

		// Update the formData object
		formData.append(
			"newFile",
			this.state.selectedFile,
			this.state.selectedFile.name
		);

		// Details of the uploaded file
		console.log(this.state.selectedFile);

		// Request made to the backend api
		// Send formData object

		axios.post("api/uploadfile", formData)
			
		
		
	};
	

	// File content to be displayed after
	// file upload is complete
	
	fileData = () => {

		if (this.state.selectedFile) {

			return (
				<div>
					<h2>File Details:</h2>

					<p>File Name: {this.state.selectedFile.name}</p>


					<p>File Type: {this.state.selectedFile.type}</p>


					<p>
						Last Modified:{" "}
						{this.state.selectedFile.lastModifiedDate.toDateString()}
					</p>

				</div>
			);
		} else {
			return (
				<div>
					<br />
					<h4>Choose before Pressing the Upload button</h4>
				</div>
			);
		}
	};

	render() {

		return (
			<div>
				<h1>
					GeeksforGeeks
				</h1>
				<h3>
					File Upload using React!
				</h3>
				<div>
					
					<input type="file" id="newFile" name="newFile" onChange={this.onFileChange} />
					<button onClick={ this.onFileUpload}>
						Upload!
						</button>
					
				</div>
				{this.fileData()}
				
			</div>
		);
	}
}
ReactDOM.render(
   <App />,
    document.getElementById("content")
);

