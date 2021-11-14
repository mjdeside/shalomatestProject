import { ShalomeTestProjectTemplatePage } from './app.po';

describe('ShalomeTestProject App', function() {
  let page: ShalomeTestProjectTemplatePage;

  beforeEach(() => {
    page = new ShalomeTestProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
